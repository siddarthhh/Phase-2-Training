<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="Ecom.PurchaseHistory" %>

<!DOCTYPE html>
<html>
<head>
    <title>Purchase History</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 20px;
        }
        h2 {
            text-align: center;
            color: #343a40;
            font-weight: 600;
            margin-bottom: 30px;
        }
        .gridview-container {
            max-width: 1000px;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }
        .gridview-container table {
            width: 100%;
            border-collapse: collapse;
        }
        .gridview-container th, .gridview-container td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #dee2e6;
        }
        .gridview-container th {
            background-color: #007bff;
            color: #ffffff;
            font-size: 14px;
        }
        .gridview-container tr:last-child td {
            border-bottom: none;
        }
        .gridview-container td {
            font-size: 14px;
        }
        .gridview-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>My Purchase History</h2>
        <div class="gridview-container">
            <asp:GridView ID="gvPurchaseHistory" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
