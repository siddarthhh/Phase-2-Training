<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecom.Login" %>

<!DOCTYPE html>

<html>
<head>
    <title>Login</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #e9ecef;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        h2 {
            text-align: center;
            color: #343a40;
            font-weight: 600;
            margin-bottom: 20px;
        }
        form {
            background-color: #ffffff;
            padding: 30px 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }
        div {
            margin-bottom: 15px;
        }
        label {
            font-size: 14px;
            color: #495057;
            display: block;
            margin-bottom: 5px;
        }
        input[type="text"],
        input[type="password"] {
            padding: 12px 15px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            font-size: 14px;
            width: 100%;
            box-sizing: border-box;
            transition: border-color 0.3s ease;
        }
        input[type="text"]:focus,
        input[type="password"]:focus {
            border-color: #80bdff;
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }
        .submit-button {
            background-color: #007bff;
            color: white;
            padding: 12px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
            transition: background-color 0.3s ease;
        }
        .submit-button:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: red;
            margin-top: 10px;
            text-align: center;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      
        <h2>Ecommerce Login</h2>
        <div>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="submit-button" OnClick="btnLogin_Click" />
        </div>
        <div>
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
        <div class="form-group">
     <label>New user?</label>
     <a href="Register.aspx">Register</a>
 </div>
    </form>
</body>
</html>
