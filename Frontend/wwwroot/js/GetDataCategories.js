protectedUrl = 'https://localhost:7101/api/expenses/categories';
token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsInN1YiI6IjQxYjRlMmE1LTU1ZTktNDdhNS1iZTZiLTcyMThiZmFmNTFiNSIsIm5hbWUiOiJhZG1pbkBhZG1pbi5jb20iLCJuYmYiOjE2OTUzMTYyOTAsImV4cCI6MTY5NTkyMTA5MCwiaWF0IjoxNjk1MzE2MjkwLCJpc3MiOiJhc3Npc3RhbnQtYXV0aC1hcGkiLCJhdWQiOiJhc3Npc3RhbnQtY2xpZW50In0.jlQJa9ZHdhKABPD-Y1rRMZgKjZzlXFXn-nw3W6Lb8Ik'


async function GetData() {

    const response = await fetch(protectedUrl, {
        headers: {
            Authorization: 'Bearer ' + token
        }
    }); 

    const json = await response.json();

    //console.log(json.result);
    let ResultFunction = SortData(json.result);
    console.log(ResultFunction);

    let Resutl = json.result;

    new Chart(
        document.getElementById('acquisitions_3'),
        {
            type: 'bar',
            data: {
                labels: ResultFunction.map(row => row.id),
                datasets: [
                    {
                        label: 'Count category',
                        data: ResultFunction.map(row => row.id)
                    }
                ]
            }
        }
    );
    return json;
}
GetData();



async function SortData(dataResutl) {

    let ArrayCategory = [];
    let i = 0;
    while (i < dataResutl.length) {

        urlCategoriedID = `https://localhost:7101/api/expenses/category_id/${dataResutl[i].id}`

        const response = await fetch(urlCategoriedID, {
            headers: {
                Authorization: 'Bearer ' + token
            }
        });

        let json = await response.json();

        ArrayCategory.push(json.result);
        i++;
    }
    console.log(ArrayCategory);
    DataCount(ArrayCategory);
    return ArrayCategory;
}

async function DataCount(data) {

    console.log(data);
    let i, k = 0;

    let CategoryCount = [];

    while (i < data.length) {
        while (k < data[i].length) {

            let SubCateCount = data[i][k].count + SubCateCount;
            k++;
        }
        CategoryCount.push(SubCateCount);
        i++;
    }

    console.log(data[0][0].count)
    console.log(data[1].length);
    console.log(CategoryCount);
}