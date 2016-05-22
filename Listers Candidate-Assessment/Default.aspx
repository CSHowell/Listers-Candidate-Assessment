<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Listers_Candidate_Assessment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <style>
        body
        {
            margin-left: 5px;
        }


    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView runat="server" ID="gvCars" AllowSorting="true"  OnSorting="gvCars_Sorting" CssClass="table" Width="95%" />

        <br />
        <asp:Button runat="server" ID="btnLoadMoreCars" Text="Load more cars" OnClick="btnLoadMoreCars_Click" CssClass="btn btn-primary" />
         
        <br /><br />
        Select Manufacturer: <asp:DropDownList runat="server" ID="dlManufacturers"  AutoPostBack="true" OnSelectedIndexChanged="dlManufacturers_SelectedIndexChanged"/>
           
    </div>
    </form>
</body>
</html>
