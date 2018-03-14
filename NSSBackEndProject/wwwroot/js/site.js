// Write your JavaScript code in the www.root folder:
//include the search bar for the books:

﻿$("#bookGrid").on("click", evt => {

    const apiId = evt.target.parentElement.id.split("--")[1];
    console.log(apiId);
    const book = BookStore.books.find(m => apiId === m.id);
    console.log(book);
    $.ajax({
        method: "POST",
        url: `/Books/Track?apiId=${apiId}&title=${book.volumeInfo.title}&bookAuthor=${book.volumeInfo.authors}&bookImage=${book.volumeInfo.imageLinks.thumbnail}&bookDescription=${book.volumeInfo.description}`
    });



});


$("#bookSearch__button").click(evt => {
    const userSearchString = $("#bookSearch").val();
    $.ajax({
        method: "GET",
        url: `https://www.googleapis.com/books/v1/volumes?q=${userSearchString}&maxResults=40`
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


            if ((idx + 1) % 4 === 0) {
                titles += "</div><div class='row'>";
            }
        });

        titles += "</div>";
        //console.log(titles)
        $("#bookGrid").html(titles);

    });
});
