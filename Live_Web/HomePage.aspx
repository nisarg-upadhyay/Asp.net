<%@ Page Title="" Language="C#"    MasterPageFile="~/Master_1.Master"  AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Live_Web.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">

            <div class="sfbg nojsv" style="margin-top: -20px">
                <div class="sfbgg">
                   <a href="Swamiji.aspx"> <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Swamiji meditating.jpg" Height="300 px" Width="260 px" /></a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <a href="Thakur.aspx"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/thakur.jpg" Height="300 px" Width="260 px" /> </a>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
               <a href="Holy Mother.aspx"> <asp:Image ID="Image3" CssClass="img-fluid" runat="server" ImageUrl="~/Images/Holy_mother_sarada.jpg" Height="300 px" Width="260 px" /></a>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
