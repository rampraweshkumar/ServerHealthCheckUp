<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server Health Checkup Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1> Server Health Report</h1>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Server IP" ItemStyle-Width="50">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("IP") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Server Name" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Server Region" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Region") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Server Status" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="Button1" runat="server" Text="Show All" OnClick="Button1_Click" />
            <asp:TextBox ID="lblIP" runat="server" ToolTip="Enter Server IP"></asp:TextBox>  
            <asp:Button ID="Button2" runat="server" Text="SearchByIP" OnClick="Button2_Click" />
            <asp:TextBox ID="serverName" runat="server" ToolTip="Enter Server Name"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="SearchByName" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
