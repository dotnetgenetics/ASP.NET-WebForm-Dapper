<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDSampleNoValidation.aspx.cs" Inherits="ASPWebFormDapperDemo.CRUDSampleNoValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #tblEntryForm{
            margin-top:50px;
            border: 2px solid lightgray;
            width: 500px;
            border-collapse: collapse;
            border-spacing: 0;
        }

        #tblEntryForm td  {
            border:2px solid lightgray;
        }

        #tblEntryForm div{
            text-align:center;
            font-weight: bold;
        }

        #tblEntryForm span{
            margin-left: 0px;
        }

        #lblMessage {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <table id="tblEntryForm">
            <tr>
                <td colspan="3">
                    <div>Customer Information Entry Form</div>
                </td>
            </tr>
            <tr>
                <td>
                    CompanyName:
                </td>
                <td>                    
                    <asp:TextBox ID="txtCompanyName"  runat="server" Width="150" />
                </td>
            </tr>
            <tr>                
                <td>
                    Address:                    
                </td>
                <td>
                    <asp:TextBox ID="txtAddress"  runat="server" Width="150" />
                </td>
            </tr>
            <tr>                
                <td>
                    City:                    
                </td>
                <td>
                    <asp:TextBox ID="txtCity"  runat="server" Width="150" />
                </td>
            </tr>
             <tr>                
                <td>
                    State:                    
                </td>
                <td>
                    <asp:TextBox ID="txtState"  runat="server" Width="150" />
                </td>
            </tr>
             <tr>                
                <td>
                    Intro Date:                    
                </td>
                <td>
                    <asp:TextBox ID="txtIntroDate"  type="date" runat="server" Width="150" />
                </td> 
            </tr>
             <tr>                
                <td>
                    Credit Limit:                    
                </td>
                <td>
                    <asp:TextBox ID="txtCreditLimit"  runat="server" Width="150" />
                </td>                  
            </tr>
            <tr>                
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnAdd_Click"/>
                </td>
            </tr>
        </table>
       <div>
        <br />
        <asp:GridView ID="gvCustomer" ValidateRequestMode="Enabled" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CustomerID" 
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gvCustomer_PageIndexChanging"
            OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="Empty Customer Database">
            <Columns>                
                <asp:TemplateField HeaderText="Company Name" ItemStyle-Width="130">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCompanyName1"  runat="server" Text='<%# Eval("CompanyName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddress1"  runat="server" Text='<%# Eval("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCity1"  runat="server" Text='<%# Eval("City") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtState1"  runat="server" Text='<%# Eval("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Intro Date" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblIntroDate" runat="server" Text='<%# Eval("IntroDate", "{0:yyyy-MM-dd}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIntroDate1"  runat="server" Text='<%# Eval("IntroDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit Limit" ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblCreditLimit" runat="server" Text='<%# Eval("CreditLimit", "{0:N2}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCreditLimit1"  runat="server" Text='<%# Eval("CreditLimit") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ButtonType="Button"/>       
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
   </form>
</body>
</html>
