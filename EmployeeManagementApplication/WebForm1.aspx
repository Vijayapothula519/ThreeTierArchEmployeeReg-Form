<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmployeeManagementApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 0px auto; padding-left: 370px; padding-right: 30px; overflow: auto;">
            <table>
                <tr>
                    <td colspan="2" style="background-color: Green; height: 30px; color: White;"
                        align="center">Employee Registration Form
                    </td>
                </tr>
                <tr>
                    <td>Employee Id </td>
                    <td>
                        <asp:TextBox Enabled="false" ID="txt_empId" Width="150px" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Firstname* </td>
                    <td>
                        <asp:TextBox ID="txt1" Width="150px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txt1" ErrorMessage="Please Enter Firstname" EnableClientScript="false" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Lastname </td>
                    <td>
                        <asp:TextBox ID="txt2" Width="150px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender* </td>
                    <td>
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                  <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rblGender" ErrorMessage="Please select a gender" EnableClientScript="false" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email* </td>
                    <td>
                        <asp:TextBox ID="txt3" Width="150px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvf3" runat="server" ControlToValidate="txt3" ErrorMessage="Please Enter Email" EnableClientScript="false" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Mobile* </td>
                    <td>
                        <asp:TextBox ID="txt4" Width="150px" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txt4" ErrorMessage="mobile start with 7 or 8 or 9" EnableClientScript="false" ForeColor="red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>SelectState*</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlstate">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Telangana" Value="Telangana"></asp:ListItem>
                            <asp:ListItem Text="Andhrapradesh" Value="Andhrapradesh"></asp:ListItem>
                            <asp:ListItem Text="New South Wales" Value="New South Wales"></asp:ListItem>
                            <asp:ListItem Text="sichuan" Value="">sichuan</asp:ListItem>
                            <asp:ListItem Text="paris" Value="">paris</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>SelectCountry*</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlcountry">
                            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="India" Value="India"></asp:ListItem>
                            <asp:ListItem Text="Australia" Value="Australia"></asp:ListItem>
                            <asp:ListItem Text="china" Value="">china</asp:ListItem>
                            <asp:ListItem Text="France" Value="">France</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td align="center" >
                        <asp:Button ID="BtnSave" runat="server" Width="100px" Text="Save" OnClick="Insert_Data" />
                    </td>
                    <td align="center" >
                        <asp:Button ID="BtnUpdate" runat="server" visbale="false" Width="100px" Text="Update" OnClick="Update_Data" />
                    </td>
                    <td align="center" >
                        <asp:Button ID="BtnClear" runat="server" visbale="false" Width="100px" Text="Clear" OnClick="BtnClear_Click" />
                    </td>
                </tr>
                </table>
        </div>

         <h2>Employee Data</h2>


        <asp:GridView ID="EmployeeGrid" AutoGenerateColumns="False" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
            OnRowDeleting="EmployeeGrid_RowDeleting" OnRowUpdating="EmployeeGrid_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Emp No">
                    <ItemTemplate>
                        <asp:Label ID="lbl_empno" runat="server" Text='<%#Eval("Empno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Firstname">
                    <ItemTemplate>
                        <asp:Label ID="lbl_fname" runat="server" Text='<%#Eval("Firstname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lastname">
                    <ItemTemplate>
                        <asp:Label ID="lbl_lname" runat="server" Text='<%#Eval("Lastname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="lbl_gender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Email" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <asp:Label ID="lbl_mobile" runat="server" Text='<%#Eval("Mobile") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lbl_state" runat="server" Text='<%#Eval("State") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="Editbtn" runat="server" CausesValidation="False"
                            CommandName="Update" Text="Edit"></asp:LinkButton>
                        <asp:LinkButton ID="DelBtn" runat="server" CausesValidation="False"
                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete?');"
                            Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lbl_Message" runat="server"></asp:Label>
    </form>
</body>
</html>
