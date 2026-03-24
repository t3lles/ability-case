const API_URL = 'http://localhost:5000/api/tickets';

document.addEventListener('DOMContentLoaded', fetchTickets);

const statusMap = { 0: 'Aberto', 1: 'Em Andamento', 2: 'Concluído' };

async function fetchTickets() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) throw new Error('Network response was not ok');

        const tickets = await response.json();
        const tableBody = document.getElementById('ticketsTableBody');
        tableBody.innerHTML = '';

        tickets.forEach(ticket => {
            const statusText = statusMap[ticket.status] ?? 'Aberto';
            const row = `
                <tr>
                    <td>
                        <strong>${ticket.title}</strong><br>
                        <small>${ticket.description || ''}</small>
                    </td>
                    <td>
                        <span class="status-${statusText.toLowerCase().replace(' ', '-')}">
                            ${statusText}
                        </span>
                    </td>
                    <td>
                        ${ticket.status !== 2 ?
                    `<button onclick="completeTicket('${ticket.id}')">Concluir</button>` :
                    '✅'}
                    </td>
                </tr>
            `;
            tableBody.innerHTML += row;
        });
    } catch (error) {
        console.error('Error fetching tickets:', error);
    }
}

async function createTicket() {
    const title = document.getElementById('titleInput').value;
    const description = document.getElementById('descriptionInput').value;

    if (!title) return alert('Please enter a title');

    const newTicket = {
        title: title,
        description: description
    };

    try {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newTicket)
        });

        if (response.ok) {
            document.getElementById('titleInput').value = '';
            document.getElementById('descriptionInput').value = '';
            fetchTickets();
        }
    } catch (error) {
        console.error('Error creating ticket:', error);
    }
}

async function completeTicket(id) {
    try {
        const response = await fetch(`${API_URL}/${id}`, {
            method: 'PUT'
        });

        if (response.ok) {
            fetchTickets();
        }
    } catch (error) {
        console.error('Error updating ticket:', error);
    }
}