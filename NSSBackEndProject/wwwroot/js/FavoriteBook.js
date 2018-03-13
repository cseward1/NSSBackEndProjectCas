//Allow the Favorite Book Button to bring the user to another page with their favorite movies listed 

$(".AnotherFavoriteBookAdded").click(evt => {
    console.log("this favorite book button fired")
    const userSearchString = $("#bookSearch").val()
    $.ajax({
        method: "POST",

        url: `https://www.googleapis.com/books/search/book?api_key=AIzaSyB6LNe_ZZEr85uPkxXTP3fT78vlrevye8U${bookdb.key}&language=en-US&query=${userSearchString}&page=1&include_adult=false`
    })

       

    
})