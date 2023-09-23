const form = document.getElementById("login-form");

/*
form.addEventListener('submit', function (e) {
    e.preventDefault();
    function sleep(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    //sleep(2000).then(() => PostForm());

    PostForm();
})
*/
PostForm();

async function PostForm() {
    const NameTextBox = document.getElementById('UserName').value;
    const Password = document.getElementById('Password').value;

    const form = {
        UserName: NameTextBox,
        Password: Password
    };

    //console.log(NameTextBox);
    //console.log(Password);

    const response = await fetch('https://localhost:7100/api/auth/login', {
        method: 'POST',
        headers: {
            "Accept": "application/json ",
            "Content-type": "application/json",
        },
        body: JSON.stringify(form)
    })

    const json = await response.json();

    //console.log("This json PostForm "+ json.result.token)

    //window.sessionStorage.clear();
    window.sessionStorage.setItem('jwt', json.result.token);
    window.location.href = 'https://localhost:7200/Home';
}
