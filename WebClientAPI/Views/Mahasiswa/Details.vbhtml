@ModelType WebClientAPI.Mahasiswa
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Mahasiswa</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nim)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nim)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nama)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nama)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IPK)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IPK)
        </dd>

    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
