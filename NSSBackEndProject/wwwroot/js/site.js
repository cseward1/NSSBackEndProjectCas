// Write your JavaScript code in the www.root folder:
//include the search bar for the books:

﻿$("#bookGrid").on("click", evt => {
    console.log("id", volumeInfo.id)
    const apiId = evt.target.parentElement.id.split("--")[1]
    const book = BookStore.books.find(m => parseInt(apiId) === m.id)
    window.location = `/Book/Track/?apiId=${volumeInfo.id}&title=${volumeInfo.title}&authors=${volumeInfo.authors}&imageLinks=${volumeInfo.imageLinks.thumbnail}&description=${volumeInfo.description}`
     
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
                <div class="col-md-3 bookGrid__book" id="book--${m.volumeInfo.id}">
                    <h2 class="fakeLink">${m.volumeInfo.title}</h2>
                    <h2 class="fakeLink">${m.volumeInfo.authors}</h2>
                    <h2 class="fakeLink">${m.volumeInfo.description}</h2>
                     <img class="fakeLink" src=${m.volumeInfo.imageLinks.thumbnail} />    
                    <img class="fakeLink" src="https://www.googleapis.com/books/v1/volumes?q=${m.volumeInfo.imageLinks.thumbnail}" />
src="https://books.google.com/books?string thumbnail_url;
                </div>
            `


            if ((idx + 1) % 4 === 0) {
                titles += "</div><div class='row'>"
            }
        })

        titles += "</div>"
        console.log(titles)
        $("#bookGrid").html(titles)

    })
});
