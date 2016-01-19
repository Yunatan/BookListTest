function insertParam(key, value) {
    key = encodeURI(key); value = encodeURI(value);

    var kvp = document.location.search.substr(1).split('&');

    var i = kvp.length; var x; while (i--) {
        x = kvp[i].split('=');

        if (x[0] == key) {
            x[1] = value;
            kvp[i] = x.join('=');
            break;
        }
    }

    if (i < 0) { kvp[kvp.length] = [key, value].join('='); }
    kvp = kvp.filter(Boolean);
    window.history.pushState(value, key, '?' + kvp.join('&'));
}

function checkIsbn(field, rules, j, options) {
    var isbn = field.val(); 

    isbn = isbn.replace(/[^\dX]/gi, "");
    if (isbn.length !== 10)
    {
        return "* ISBN is not valid";
    }

    var nums = isbn.split("");
    if (nums[9].toUpperCase() === "X")
    {
        nums[9] = "10";
    }

    var sum = 0;
    for (var i = 0; i < nums.length; i++)
    {
        sum += ((10 - i) * parseInt(nums[i]));
    }

    if ((sum % 11) !== 0) {
        return "* ISBN is not valid";
    }
}