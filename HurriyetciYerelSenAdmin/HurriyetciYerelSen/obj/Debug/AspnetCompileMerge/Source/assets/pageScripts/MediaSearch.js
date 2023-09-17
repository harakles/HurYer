$('#MediaSearchButton').on("click", function () {
    const value = $('#MediaSearch').val();
    const typeID = $('#MediaSearch').data("typeid");
    const url = `/TR/MediaAra?TypeID=${typeID}&Value=${value}`;
    window.location.href = url;
});