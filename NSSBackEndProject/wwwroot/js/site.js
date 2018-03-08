﻿// Write your JavaScript code in the www.root folder:
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
        url: `https://www.googleapis.com/books/v1/volumes?q=${userSearchString}&maxResults=40`
    }).then(res => {
        console.log("does this button work?", res)
        BookStore.books = res.items
        console.log(res.items)
        let titles = "<div class='row'>"
       
        res.items.forEach((m, idx) => {
            console.log(m)
            titles += `
                <div class="col-md-3 bookGrid__book" id="book--${m.volumeInfo.id}">
                    <h4 class="fakeLink"><strong>${m.volumeInfo.title}</strong></h4>
                    <div class="fakeLink">${m.volumeInfo.authors}</div>
                     <img class="fakeLink" src=${m.volumeInfo.imageLinks ? m.volumeInfo.imageLinks.thumbnail : "" } />    

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
