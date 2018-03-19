$("#userSearch__button").click(evt => {
    const userSearchString = $("#userSearch").val();
    $.ajax({
        method: "GET",
        url: `GET https://www.googleapis.com/books/v1/users/userId/bookshelves`
    }).then(res => {
        // console.log("does this button work?")
        BookStore.books = res.items;
        // console.log(res.items)
        let titles = "<div class='row'>";

        res.items.forEach((m, idx) => {
            //console.log(m.id)
            titles += `
                <div class="col-md-3 bookGrid__book" id="book--${m.id}">
                <img class="fakeLink" src=${m.volumeInfo.imageLinks ? m.volumeInfo.imageLinks.thumbnail : ""} />    
                <h4 class="fakeLink"><strong>${m.volumeInfo.title}</strong></h4>
                <div class="fakeLink">${m.volumeInfo.authors}</div>
                <button <a asp-area="" asp-controller="Books" asp-action="Index" class = "AnotherFavoriteBookAdded">Add to Bookshelf</button>
                </div>
            `;
        });
    });
});