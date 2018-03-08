// Write your JavaScript code.
//include the search bar for the books:

﻿$("#bookGrid").on("click", evt => {
    const apiId = evt.target.parentElement.id.split("--")[1]
    const book = BookStore.books.find(m => parseInt(apiId) === m.id)

    window.location = `/Book/Track/?apiId=${book.id}&title=${book.title}&authors={book.author}`
})


$("#bookSearch__button").click(evt => {
    const userSearchString = $("#bookSearch").val()
    $.ajax({
        method: "GET",
        url: `https://www.googleapis.com/books/v1/volumes?q=${userSearchString}`
    }).then(res => {
        console.log("does this button work?", res)
        BookStore.books = res.items
        console.log(res.items)
        let titles = "<div class='row'>"
       
        res.items.forEach((m, idx) => {
            console.log(m)
            titles += `
                <div class="col-md-3 bookGrid__book" id="book--${m.id}">
                    <h2 class="fakeLink">${m.title}</h2>
                    <img class="fakeLink" src="https://image.tmdb.org/t/p/w154${m.poster_path}" />
                </div>
            `
            if ((idx + 1) % 4 === 0) {
                titles += "</div><div class='row'>"
            }
        })

        titles += "</div>"

        $("#bookGrid").html(titles)

    })
});
//end
