<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSearchProduct.aspx.cs" Inherits="Ecom.CustomerSearchProduct" %>

<!DOCTYPE html>
<html>
<head>
    <title>Customer - Search Products</title>
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
        .search-container {
            text-align: center;
            margin-bottom: 20px;
        }
        input[type="text"] {
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            font-size: 14px;
            width: 60%;
            max-width: 400px;
            box-sizing: border-box;
            transition: border-color 0.3s ease;
        }
        input[type="text"]:focus {
            border-color: #80bdff;
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }
        .btn {
            background-color: #007bff;
            color: white;
            padding: 8px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
            margin: 5px;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .gridview-container {
            max-width: 90%;
            margin: 0 auto;
            overflow-x: auto;
        }
        .gridview-container table {
            width: 100%;
            border-collapse: collapse;
            background-color: #ffffff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
            overflow: hidden;
        }
        .gridview-container th, .gridview-container td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #dee2e6;
            font-size: 14px;
        }
        .gridview-container th {
            background-color: #007bff;
            color: #ffffff;
        }
        .gridview-container tr:last-child td {
            border-bottom: none;
        }
        .gridview-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Customer - Search Products</h2>
        <div class="search-container">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter product name or details"></asp:TextBox>
            <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn" OnClick="btnSearch_Click" />
        </div>
        
        <div class="gridview-container">
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProducts_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnBuy" runat="server" Text="Buy" CommandName="BuyProduct" CommandArgument='<%# Eval("ProductID") %>' CssClass="btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="search-container">
            <asp:Button ID="btnShowMyOrders" runat="server" Text="Show My Orders" CssClass="btn" OnClick="btnShowMyOrders_Click" />
        </div>
    </form>
</body>
</html>
