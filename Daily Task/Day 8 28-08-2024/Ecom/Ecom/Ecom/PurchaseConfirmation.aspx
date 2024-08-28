<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseConfirmation.aspx.cs" Inherits="Ecom.PurchaseConfirmation" %>

<!DOCTYPE html>
<html>
<head>
    <title>Purchase Confirmation</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f6f8;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .confirmation-container {
            background-color: #ffffff;
            padding: 30px 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 100%;
            max-width: 500px;
        }
        h2 {
            color: #28a745;
            font-weight: 600;
            margin-bottom: 20px;
        }
        p {
            font-size: 16px;
            color: #343a40;
        }
        .product-id {
            font-weight: bold;
            color: #007bff;
        }
        .home-link {
            display: inline-block;
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: #ffffff;
            border-radius: 5px;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }
        .home-link:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <div class="confirmation-container">
        <h2>Thank you for your purchase!</h2>
        <p>You have successfully purchased the product with ID: <span class="product-id"><asp:Label ID="lblProductID" runat="server"></asp:Label></span></p>
        <a href="CustomerSearchProduct.aspx" class="home-link">Go to Home</a>
    </div>
</body>
</html>
