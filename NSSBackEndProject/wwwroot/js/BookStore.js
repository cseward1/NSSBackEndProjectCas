const bookCollection = Symbol()  // Super const


const BookStore = Object.create(null, {
    init: {
        value: function () {
            this[bookCollection] = []
        }
    },
    movies: {
        set: function (bookArray) {
            this[bookCollection] = bookArray
        },
        get: function () {
            return this[bookCollection]
        }
    }
})