<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="Task1.crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        form {
            width: 60%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
        }

        label {
            display: block;
            margin-bottom: 8px;
        }

        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 16px;
            box-sizing: border-box;
        }

        button {
            background-color: #4caf50;
            color: #fff;
            padding: 10px 15px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }

        button:hover {
            background-color: #45a049;
        }

        table {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #4caf50;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label for="tableName">Name:</label>
                <asp:TextBox ID="tableName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="columnName">Column:</label>
                <asp:TextBox ID="columnName" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="dataType">Data Type:</label>
                <asp:TextBox ID="dataType" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            </div>
        </div>
        <div>
            <label for="username">Username:</label>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Create" OnClick="btnInsert_Click" />
        </div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting"
            DataKeyNames="name" OnRowEditing="GridView2_RowEditing" OnRowCancelingEdit="GridView2_RowCancelingEdit"
            OnRowUpdating="GridView2_RowUpdating" AllowPaging="True" PageSize="10">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
                <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Edit" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
