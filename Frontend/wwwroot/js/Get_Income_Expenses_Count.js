protectedUrl_income = 'https://localhost:7102/api/income/count'
protectedUrl_expenses = 'https://localhost:7101/api/expenses/category_count'

tokenSafe = sessionStorage.getItem('jwt');

async function GetData() {

    const response_income = await fetch(protectedUrl_income, {
        headers: {
            Authorization: 'Bearer ' + tokenSafe
        }
    });

    const response_expenses = await fetch(protectedUrl_expenses, {
        headers: {
            Authorization: 'Bearer ' + tokenSafe
        }
    });

    const json_income = await response_income.json();
    const json_expenses = await response_expenses.json();

    const Data_expenses = json_expenses.result;
    const Data_income = json_income.result;

    let i = 0;
    let SumExpenses = 0;


    for (i = 0; i < Data_expenses.length; ++i) {

        SumExpenses = SumExpenses + Data_expenses[i].count;
    }


    const DiferenceIncomeExpenses = Data_income - SumExpenses;

    const Data = [
        { name: "Income", count: DiferenceIncomeExpenses },
        { name: "Expenses", count: SumExpenses }
    ] 

    console.log(Data);

    new Chart(
        document.getElementById('diagramm_expenses_income'),
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
}

GetData();