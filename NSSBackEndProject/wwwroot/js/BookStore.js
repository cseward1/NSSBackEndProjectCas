const bookCollection = Symbol()  // Super const


const BookStore = Object.create(null, {
    init: {
        value: function () {
            this[bookCollection] = []
        }
    },
    books: {
        set: function (bookArray) {
            this[bookCollection] = bookArray
        },
        get: function () {
            console.log("books.getrunning", this[bookCollection])
            return this[bookCollection]
        }
    }
})