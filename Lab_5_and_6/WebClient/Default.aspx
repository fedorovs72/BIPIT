<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="position: absolute; left: 400px; margin: 20px;" >
      
            <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" Width="700px" Height="500px" CellPadding="3" GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">


            <Columns>
                             
                <asp:TemplateField HeaderText="ID перемещения" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_tr" runat="server" Text='<%# Eval("id_tr") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>                    

                </asp:TemplateField>
                <asp:TemplateField HeaderText="id экспоната" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_exp" runat="server" Text='<%# Eval("id_exp_fk") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Экспонат" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_exp" runat="server" Text='<%# Eval("name_exp") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="id зала" Visible="false" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="id_h" runat="server" Text='<%# Eval("id_h_fk") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Зал" ItemStyle-Width="150">
                    <ItemTemplate>
                        <asp:Label ID="name_h" runat="server" Text='<%# Eval("name_h") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>

                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Дата перемещения" ItemStyle-Width="150" >
                    <ItemTemplate>
                        <asp:Label ID="date" runat="server" Text='<%# Eval("date","{0:dd.MM.yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Автор приказа на перемещение" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="autor_order" runat="server" Text='<%# Eval("autor_order") %>'></asp:Label>
                    </ItemTemplate>
                     <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Black" BorderWidth="1px" ForeColor="Black" />
                    <ItemStyle Width="50px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:TemplateField>
            </Columns>
              <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
              <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
              <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
             <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
              <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#594B9C" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#33276A" />
          </asp:GridView>
       
        <div style="padding: 15px;">
            <form >
                Экспонат
                <br>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="400px" Height="30px">
                </asp:DropDownList>
                <br />
      
                Зал <br>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="400px" Height="30px" >
                </asp:DropDownList>
                <br />
       
                Дата
                <br>
                <asp:TextBox ID="TextBox1" TextMode="Date" runat="server" >2020-10-11</asp:TextBox>
                <br />
                Автор приказа на перемещение<br>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                <div style="padding: 15px;">
       
                    <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="Дата не заполнена" Visible="False"></asp:Label>

                </div>
                <div style="padding-top: 15px; width: 300px;">
                    <asp:Button ID="Button" runat="server" Text="Добавить" OnClick="Button_Click"/>
                </div>
                <div >
                    <asp:Label ID="Label5" runat="server" ForeColor="Red"  Text="Такая запись уже существует!" Visible="False"></asp:Label>
       
                </div><br>
        
            </form>
            </div>
    </div>

</asp:Content>
