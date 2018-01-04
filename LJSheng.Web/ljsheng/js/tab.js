var oTab = document.getElementById('list');
var oldBgColor = '';
var i = 0;
try{
    for (i = 0; i < oTab.tBodies[0].rows.length; i++) {
        oTab.tBodies[0].rows[i].style.background = i % 2 ? '#fff' : '';
        oTab.tBodies[0].rows[i].onmouseover = function () {
            oldBgColor = this.style.background;
            this.style.background = '#ffffd4';
        };
        oTab.tBodies[0].rows[i].onmouseout = function () {
            this.style.background = oldBgColor;
        };

    }
    $("#list tr:even").css('background', '#f2f8ff');
}
catch(err){}