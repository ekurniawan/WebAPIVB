@ModelType WebClientAPI.Mahasiswa
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="hidden" name="Nim" value="@Model.Nim" />
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
