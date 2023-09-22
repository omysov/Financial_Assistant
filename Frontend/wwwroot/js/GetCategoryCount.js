
protectedUrl = 'https://localhost:7101/api/expenses/category_count'

tokenSafe = sessionStorage.getItem('jwt');

tokenCustomer = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImN1c3RvbWVyMDFAZ21haWwucnUiLCJzdWIiOiJhNDE0MTY3My1lOWI1LTQ3ZmYtYTg0OS0zYTY4Y2FiNTQ1MjUiLCJuYW1lIjoiY3VzdG9tZXIwMUBnbWFpbC5ydSIsIm5iZiI6MTY5NTQyMDI2OSwiZXhwIjoxNjk2MDI1MDY5LCJpYXQiOjE2OTU0MjAyNjksImlzcyI6ImFzc2lzdGFudC1hdXRoLWFwaSIsImF1ZCI6ImFzc2lzdGFudC1jbGllbnQifQ.EE7WMZqwHVTzF2YuEjG5lDr2kBSqXGv6FCDOoEM8JbQ';

tokenAdmin = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsInN1YiI6IjQxYjRlMmE1LTU1ZTktNDdhNS1iZTZiLTcyMThiZmFmNTFiNSIsIm5hbWUiOiJhZG1pbkBhZG1pbi5jb20iLCJuYmYiOjE2OTUzNzQzNzcsImV4cCI6MTY5NTk3OTE3NywiaWF0IjoxNjk1Mzc0Mzc3LCJpc3MiOiJhc3Npc3RhbnQtYXV0aC1hcGkiLCJhdWQiOiJhc3Npc3RhbnQtY2xpZW50In0.F0XV7yTA21pmJYUH_8U93G3iLUy2fwbixGJJaGQ4ohk';


async function GetData() {

    const response = await fetch(protectedUrl, {
        headers: {
            Authorization: 'Bearer ' + tokenSafe
        }
    });
    console.log(tokenSafe);

    const json = await response.json();

    const Data = json.result;
    console.log(Data);

    new Chart(
        document.getElementById('acquisitions'),
        {
            type: 'doughnut',
            data: {
                labels: Data.map(row => row.name),
                datasets: [
                    {
                        label: 'Category count',
                        data: Data.map(row => row.count)
                    }
                ]
            }
        }
    );
    return json;
}

GetData();

