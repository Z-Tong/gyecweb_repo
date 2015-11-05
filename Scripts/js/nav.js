$(document).ready(function () {
    //    nav-li hover e
    var num;
    $('.nav-main>li[id]').hover(function () {

        /*下拉框出现*/
        var Obj = $(this).attr('id');
        num = Obj.substring(3, Obj.length);
        $('#box-' + num).slideDown(300);
    }, function () {
        /*下拉框消失*/
        $('#box-' + num).hide();
    });
    //    hidden-box hover e
    $('.hidden-box').hover(function () {
        $(this).show();
    }, function () {
        $(this).slideUp(200);
    });
});

function getRootPath(str) {
    //获取当前网址，如： http://localhost:8083/uimcardprj/share/meun.jsp
    var curWwwPath = window.document.location.href;
    //获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
    var pathName = window.document.location.pathname;
    var pos = curWwwPath.indexOf(pathName);
    //获取主机地址，如： http://localhost:8083
    var localhostPaht = curWwwPath.substring(0, pos);
    //获取带"/"的项目名，如：/uimcardprj
    var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
    return (localhostPaht + projectName + '/' + str);
}
