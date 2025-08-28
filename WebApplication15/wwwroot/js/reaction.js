let Etext = document.getElementById('wrong')
let Email = document.getElementById('email')
let Password = document.getElementById('password')
let submit = document.getElementById('submit')
function sendLogin(){
    let request = new XMLHttpRequest()
    request.open("SEND","URL")
    request.responseType= "json"
    let bodyprams = {
        "email" : Email,
        "password" : Password
    }
    request.send(JSON.stringify(bodyprams))
    if(request.status >= 200 &&request.status <300 ){
        //continue
    }
    else{
        //error with the site
    } 
}
function checkresult(){
    let request = new XMLHttpRequest()
    request.open("GET","URL")
    request.responseType= "json"
    request.send()
    if(request.status >= 200 &&request.status <300 ){
        //continue
        let response = request.response
        if(response/*fix it with the returning value*/){
            // go to Home Page
            window.location.href = "indexHome.html";
        }
        else{
            // visibilty of the red p will be visible
            Etext.style.visibility = 'visible'
        }
    }
    else{
        //error with the site
    } }
submit.addEventListener('click', () => {
    sendLogin()
    checkresult()
})