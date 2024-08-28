<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Ecom.Products" %>

<!DOCTYPE html>
<html>
<head>
    <title>Manage Products</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }
        form {
            background-color: #ffffff;
            padding: 30px 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 600px;
        }
        h2 {
            text-align: center;
            color: #343a40;
            font-weight: 600;
            margin-bottom: 20px;
        }
        h3 {
            color: #007bff;
            font-weight: 500;
            margin-bottom: 15px;
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
        input[type="text"] {
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            font-size: 14px;
            width: 100%;
            box-sizing: border-box;
            margin-bottom: 10px;
            transition: border-color 0.3s ease;
        }
        input[type="text"]:focus {
            border-color: #80bdff;
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }
        .btn {
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-right: 10px;
            transition: background-color 0.3s ease;
        }
        .btn-primary {
            background-color: #007bff;
            color: white;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        .btn-danger {
            background-color: #dc3545;
            color: white;
        }
        .btn-danger:hover {
            background-color: #c82333;
        }
        .btn-secondary {
            background-color: #6c757d;
            color: white;
        }
        .btn-secondary:hover {
            background-color: #5a6268;
        }
        .grid-view {
            margin-top: 20px;
        }
        .grid-view table {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-view th, .grid-view td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #dee2e6;
        }
        .grid-view th {
            background-color: #007bff;
            color: white;
        }
        .grid-view tr:hover {
            background-color: #f1f1f1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Product Management</h2>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="error-message" />

        <div>
            <asp:Panel ID="pnlEdit" runat="server" CssClass="panel-edit" Visible="False">
                <h3>Edit Product</h3>
                <label for="txtEditProductName">Product Name:</label>
                <asp:TextBox ID="txtEditProductName" runat="server"></asp:TextBox><br />
                <label for="txtEditPrice">Price:</label>
                <asp:TextBox ID="txtEditPrice" runat="server"></asp:TextBox><br />
                <label for="txtEditQuantity">Quantity:</label>
                <asp:TextBox ID="txtEditQuantity" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnUpdate" Text="Update Product" runat="server" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </asp:Panel>
            
            <label for="txtProductName">Product Name:</label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />
            <label for="txtPrice">Price:</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
            <label for="txtQuantity">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnAdd" Text="Add Product" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" /><br /><br />

            <label for="txtSearch">Search Product:</label>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" Text="Search" runat="server" CssClass="btn btn-secondary" OnClick="btnSearch_Click" /><br /><br />

            <div class="grid-view">
                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProducts_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="Edit" CssClass="btn btn-primary" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteProduct" CommandArgument='<%# Eval("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
