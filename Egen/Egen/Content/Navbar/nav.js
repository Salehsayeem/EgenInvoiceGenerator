$(function () {
    var str = '#len'; //increment by 1 up to 1-nelemnts
    $(document).ready(function () {
        var i, stop;
        i = 1;
        stop = 11; //num elements
        setInterval(function() {
                if (i > stop) {
                    return;
                }
                $(str + (i++)).toggleClass('bounce');
            },
            500);
    });
});