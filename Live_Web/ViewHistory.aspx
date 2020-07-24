<%@ Page Title="" Language="C#" MasterPageFile="~/Master_2.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="Live_Web.WebForm20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <p>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <table style="border: 1px solid #A55129; background-color: #E5E4E2">
                    <tr>
                        <td style="width: 350px">
                            <table>
                                
                                    <td>
                                        <b>Name:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblId"
                                            runat="server"
                                            Text='<%#Eval("Name") %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>DutyName:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblName"
                                            runat="server"
                                            Text='<%#Eval("DutyName") %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Location:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGender"
                                            runat="server"
                                            Text='<%#Eval("Location") %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Time:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCity"
                                            runat="server"
                                            Text='<%#Eval("Time") %>'>
                                        </asp:Label>
                                    </td>
                                 </tr>
                                <tr>
                                    <td>
                                        <b>Date:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1"
                                            runat="server"
                                            Text='<%#Eval("Date") %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Status:</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2"
                                            runat="server"
                                            Text='<%#Eval("Status") %>'>
                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </p>
</asp:Content>
