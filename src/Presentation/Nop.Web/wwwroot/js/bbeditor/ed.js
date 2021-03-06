/*****************************************/
// Name: Javascript Textarea BBCode Markup Editor
// Version: 1.3
// Author: Balakrishnan
// Last Modified Date: 25/jan/2009
// License: Free
// URL: http://www.corpocrat.com
/******************************************/

var textarea;
var content;

function edToolbar(obj, webRoot) {
    document.write("<div class=\"toolbar\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/bold.gif\" title=\"Bold\" name=\"btnBold\" onClick=\"doAddTags('[b]','[/b]','" + obj + "')\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/italic.gif\" title=\"Italic\" name=\"btnItalic\" onClick=\"doAddTags('[i]','[/i]','" + obj + "')\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/underline.gif\" title=\"Underline\" name=\"btnUnderline\" onClick=\"doAddTags('[u]','[/u]','" + obj + "')\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/link.gif\" title=\"Link\" name=\"btnLink\" onClick=\"doURL('" + obj + "')\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/picture.gif\" title=\"Picture\" name=\"btnLink\" onClick=\"doImg('" + obj + "')\">");
    document.write("<img class=\"button\" src=\"" + webRoot + "BBEditor/images/code.gif\" title=\"Code\" name=\"btnCode\" onClick=\"doAddTags('[code]','[/code]','" + obj + "')\">");
    document.write("</div>");
}

function doURL(obj) {
    textarea = document.getElementById(obj);
    var url = prompt('Enter the URL:', 'http://');
    var scrollTop = textarea.scrollTop;
    var scrollLeft = textarea.scrollLeft;
    if (url != '' && url != null) {
        if (document.selection) {
            textarea.focus();
            var selNew = document.selection.createRange();
            if (selNew.text == "") {
                selNew.text = '[url]' + url + '[/url]';
            }
            else {
                selNew.text = '[url=' + url + ']' + selNew.text + '[/url]';
            }
        }
        else {
            var len = textarea.value.length;
            var start = textarea.selectionStart;
            var end = textarea.selectionEnd;

            var selNew = textarea.value.substring(start, end);

            if (selNew == "") {
                var rep = '[url]' + url + '[/url]';
            }
            else {
                var rep2 = '[url=' + url + ']' + selNew + '[/url]';
            }

            textarea.value = textarea.value.substring(0, start) + rep + textarea.value.substring(end, len);
            textarea.scrollTop = scrollTop;
            textarea.scrollLeft = scrollLeft;
        }
    }
}

function doImg(obj) {
    textarea = document.getElementById(obj);
    var url = prompt('Enter the picture URL:', 'http://');
    var scrollTop = textarea.scrollTop;
    var scrollLeft = textarea.scrollLeft;
    if (url != '' && url != null) {
        if (document.selection) {
            textarea.focus();
            var sel = document.selection.createRange();
            sel.text = '[img]' + url + '[/img]';
        }
        else {
            var len = textarea.value.length;
            var start = textarea.selectionStart;
            var end = textarea.selectionEnd;

            var rep = '[img]' + url + '[/img]';

            textarea.value = textarea.value.substring(0, start) + rep + textarea.value.substring(end, len);
            textarea.scrollTop = scrollTop;
            textarea.scrollLeft = scrollLeft;
        }
    }
}

function doAddTags(tag1, tag2, obj) {
    textarea = document.getElementById(obj);
    // Code for IE
    if (document.selection) {
        textarea.focus();
        var sel = document.selection.createRange();
        sel.text = tag1 + sel.text + tag2;
    }
    else {  // Code for Mozilla Firefox
        var len = textarea.value.length;
        var start = textarea.selectionStart;
        var end = textarea.selectionEnd;
        var scrollTop = textarea.scrollTop;
        var scrollLeft = textarea.scrollLeft;
        var rep = tag1 + sel + tag2;
        textarea.value = textarea.value.substring(0, start) + rep + textarea.value.substring(end, len);
        textarea.scrollTop = scrollTop;
        textarea.scrollLeft = scrollLeft;
    }
}