<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Asp_Training.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="row mb-5">
            <h3 class="mb-3">Data Operations using Stored Procedures</h3>
            <div class="col-6 d-flex flex-column justify-content-start align-items-center gap-3">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="User Name"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-6 d-flex flex-column justify-content-center align-items-center gap-3">
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Designation"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Department"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        <asp:ListItem>Development</asp:ListItem>
                        <asp:ListItem>Testing</asp:ListItem>
                        <asp:ListItem>Marketing</asp:ListItem>
                        <asp:ListItem>Management</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="d-flex justify-content-center align-items-center gap-5 mt-3">
                <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Insert" OnClick="btnInsert_Click" />
                <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="Button3" class="btn btn-danger" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
            </div>
        </div>
        <div class="row">
            <h3 class="mb-3">User Details</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="custom-grid">
                <EmptyDataTemplate>
                    <div>No data available</div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField HeaderText="User Id" DataField="UserId" />
                    <asp:BoundField HeaderText="First Name" DataField="Firstname" />
                    <asp:BoundField HeaderText="Last Name" DataField="Lastname" />
                    <asp:BoundField HeaderText="User Name" DataField="Username" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Designation" DataField="Designation" />
                    <asp:BoundField HeaderText="Department" DataField="Department" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="Button4" class="btn btn-primary" runat="server" Text="Select" OnClick="btnSelect_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </main>

    <style>
        .custom-grid {
            border-collapse: separate;
            border-spacing: 10px;
            margin: 0 auto;
        }

            .custom-grid th,
            .custom-grid td {
                padding: 10px;
                text-align: center;
                border-left: 1px solid;
                border-bottom: 1px solid;
            }
    </style>
</asp:Content>