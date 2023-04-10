/**
 * Variables
 */
const signupButton = document.getElementById('signup-button'),
    loginButton = document.getElementById('login-button'),
    userForms = document.getElementById('user_options-forms')

/**
 * Add event listener to the "Sign Up" button
 */
signupButton.addEventListener('click', () => {
    userForms.classList.remove('bounceRight')
    userForms.classList.add('bounceLeft')
}, false)

/**
 * Add event listener to the "Login" button
 */
loginButton.addEventListener('click', () => {
    userForms.classList.remove('bounceLeft')
    userForms.classList.add('bounceRight')
}, false)

//！--OtpClick的字要换成OtpBtn才会有Function--！


$(function () {

    $("#AdminLoginBtn").click(function () {
        location.href = "/Admin/AdminLoginPage"
    })
    $("#loginBtn").click(function () {

        var email = $("#Email").val()
        var password = $("#Password").val()

        $.post("/CustomerLogin/LoginPage", { Email: email, password: password }, function (data) {
            if (data == "Faild") {
                $("#Password").val("")
                // $("#loginError").text("Email or Password are incorrect.")
                $(".AlertMsg").children("strong").text("Email or Password are incorrect")
                $(".AlertMsg").slideDown(1000, function () {
                    setTimeout(function () {
                        $(".AlertMsg").slideUp(1000)
                    }, 2000)
                })
            }

            else {
                $("#loginError").text("")
                $(".AlertMsg").children("strong").text('Welcome Back ' + data.fullName + "!")
                $(".AlertMsg").slideDown(1000, function () {
                    setTimeout(function () {
                        location.href = "/CustomerStore/MerchandisePage"
                    }, 2000)
                })
                /*location.href = "/CustomerStore/MerchandisePage";*/
            }
        })
    })
})
