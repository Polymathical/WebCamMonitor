var loaded1 = true;
var loaded2 = true;

function reloadImage(imageId, mutex)
{
    if (mutex == false)
        return;

    mutexloaded1 = false;
    reloadImg(imageId);
}

function reloadImg(id)
{
    var obj = document.getElementById(id);
    var src = obj.src;
    var pos = src.indexOf('?');
    if (pos >= 0)
    {
        src = src.substr(0, pos);
    }
    var date = new Date();
    obj.src = src + '?v=' + date.getTime();
    return false;
}

function lolAuth()
{
    // lol authentication
    var field = 'qar';
    var url = window.location.href;

    if (url.indexOf(field + '=') == -1)
        window.location = 'nothing.html';
}
 
function load(mutex)
{
    mutex = true;
}

