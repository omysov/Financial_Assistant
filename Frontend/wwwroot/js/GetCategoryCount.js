
protectedUrl = 'https://localhost:7101/api/expenses/category_count'
token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsInN1YiI6IjQxYjRlMmE1LTU1ZTktNDdhNS1iZTZiLTcyMThiZmFmNTFiNSIsIm5hbWUiOiJhZG1pbkBhZG1pbi5jb20iLCJuYmYiOjE2OTUzNzQzNzcsImV4cCI6MTY5NTk3OTE3NywiaWF0IjoxNjk1Mzc0Mzc3LCJpc3MiOiJhc3Npc3RhbnQtYXV0aC1hcGkiLCJhdWQiOiJhc3Npc3RhbnQtY2xpZW50In0.F0XV7yTA21pmJYUH_8U93G3iLUy2fwbixGJJaGQ4ohk';
async function GetData() {

    const response = await fetch(protectedUrl, {
        headers: {
            Authorization: 'Bearer ' + token
        }
    });

    const json = await response.json();

    const Data = json.result;
    console.log(Data);
    //console.log(json.result);

    new Chart(
        document.getElementById('acquisitions_3'),
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
