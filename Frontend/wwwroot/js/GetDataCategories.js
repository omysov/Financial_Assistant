fetch('https://jsonplaceholder.typicode.com/posts/1')
    .then((response) => response.json())
    .then((json) => console.log(json));

protectedUrl = 'https://localhost:7101/api/expenses/categories';
token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGFkbWluLmNvbSIsInN1YiI6IjQxYjRlMmE1LTU1ZTktNDdhNS1iZTZiLTcyMThiZmFmNTFiNSIsIm5hbWUiOiJhZG1pbkBhZG1pbi5jb20iLCJuYmYiOjE2OTUzMTYyOTAsImV4cCI6MTY5NTkyMTA5MCwiaWF0IjoxNjk1MzE2MjkwLCJpc3MiOiJhc3Npc3RhbnQtYXV0aC1hcGkiLCJhdWQiOiJhc3Npc3RhbnQtY2xpZW50In0.jlQJa9ZHdhKABPD-Y1rRMZgKjZzlXFXn-nw3W6Lb8Ik'


async function GetData() {

    const response = await fetch(protectedUrl, {
        headers: {
            Authorization: 'Bearer ' + token
        }
    }); 

    const json = await response.json();

    console.log(json);
}
GetData();