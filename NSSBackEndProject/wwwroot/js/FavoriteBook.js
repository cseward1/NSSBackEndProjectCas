//Allow the Favorite Book Button to bring the user to another page with their favorite movies listed 

$(".AnotherFavoriteBookAdded").click(evt => {
    console.log("this button fired")
    const userSearchString = $("#bookSearch").val()
    $.ajax({
        method: "GET",

        url: `https://www.googleapis.com/books/search/book?api_key=AIzaSyB6LNe_ZZEr85uPkxXTP3fT78vlrevye8U${bookdb.key}&language=en-US&query=${userSearchString}&page=1&include_adult=false`
    }).then(res => {
        BookStore.books = res.results
        let titles = "<div class='row'>"
        res.results.forEach((m, idx) => {

            titles += `
                <div class="col-md-3 bookGrid__book" id="book--${m.id}">
                    <img class="fakeLink">${m.volumeInfo.imageLinks.thumbnail}</img>
                    <h2 class="fakeLink">${m.volumeInfo.title}</h2>
                    <h2 class="fakeLink">${m.volumeInfo.authors}</h2>
                    
                </div>
            `
            if ((idx + 1) % 4 === 0) {
                titles += "</div><div class='row'>"
            }
        })

        titles += "</div>"

        $("#bookGrid").html(titles)

    })
})