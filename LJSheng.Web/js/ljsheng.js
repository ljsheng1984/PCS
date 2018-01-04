function show(title,msg) {
    layer.open({
        type: 1,
        title: title,
        skin: 'layui-layer-rim', //加上边框
        area: ['800px', '400px'], //宽高
        content: msg
    });
}

function showiframe(title, url) {
    layer.open({
        type: 2,
        title: title,
        shadeClose: true,
        shade: false,
        maxmin: true, //开启最大化最小化按钮
        area: ['1000px', '600px'],
        content: url
    });
}
function parentiframe(title, url) {
    parent.layer.open({
        type: 2,
        title: title,
        shadeClose: true,
        shade: false,
        maxmin: true, //开启最大化最小化按钮
        area: ['800px', '500px'],
        content: url
    });
}