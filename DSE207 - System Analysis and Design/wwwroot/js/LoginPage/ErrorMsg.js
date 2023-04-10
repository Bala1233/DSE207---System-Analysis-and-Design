$(function () {
    function alphabetWithNumbers(str) {
        return /^([a-zA-Z-0-9]+)$/.test(str) && /\d/.test(str) && /[A-Z]/i.test(str);
    }
    function CheckInput(str) {
        function CheckStr(str) {
            if (str == "") {
                return false
            }
            else {
                return true
            }
        }
        return CheckStr(str)
    }
    function passwordFormat(password, type) {

        function checkFormat(str) {
            if (str == "") {
                return "required";
            } else if (str.length < 8) {
                return "length";
            } else if (!alphabetWithNumbers(password)) {
                return "format";
            } else {
                return "";
            }
        };

        var wrongType = {
            "required": type + " Password field is required.",
            "length": type + " Password must be at least 8 characters.",
            "format": type + " Password must be 8 to 16 characters&[Aa-zZ] Or [0-9]",
            "": true,
        }
        return wrongType[checkFormat(password)]
    }

    $(".ErrorMsg").click(function () {
        var name = $("#Name").val()
        var email = $(".Email").val()
        var Checkpassword = passwordFormat($(".Password").val(), "The")
        var phone = $("#Phone").val()
        var otp = $("#OtpPlace").val()

        CheckInput(name) != true ? $("#Name").next().text("The Full Name field is required.")
            : $("#Name").next().text("")

        CheckInput(email) != true ? $(".Email").next().text("The Email field is required.")
            : $(".Email").next().text("")

        Checkpassword != true ? $(".Password").next().text(Checkpassword)
            : $(".Password").next().text("")

        CheckInput(phone) != true ? $("#Phone").next().text("The Phone field is required.")
            : $("#Phone").next().text("")

        CheckInput(otp) != true ? $("#OtpPlace").next().text("The Otp field is required.")
            : $("#OtpPlace").next().text("")
    })

})