﻿function hasClassName(inElement, inClassName) {
    var regExp = new RegExp('(?:^|\\s+)' + inClassName + '(?:\\s+|$)');
    return regExp.test(inElement.className);
}

function addClassName(inElement, inClassName) {
    if (!hasClassName(inElement, inClassName))
        inElement.className = [inElement.className, inClassName].join(' ');
}

function removeClassName(inElement, inClassName) {
    if (hasClassName(inElement, inClassName)) {
        var regExp = new RegExp('(?:^|\\s+)' + inClassName + '(?:\\s+|$)', 'g');
        var curClasses = inElement.className;
        inElement.className = curClasses.replace(regExp, ' ');
    }
}

function toggleClassName(inElement, inClassName) {
    if (hasClassName(inElement, inClassName))
        removeClassName(inElement, inClassName);
    else
        addClassName(inElement, inClassName);
}

function toggleShape() {
    var shape = document.getElementById('shape');
    if (hasClassName(shape, 'ring')) {
        removeClassName(shape, 'ring');
        addClassName(shape, 'cube');
    } else {
        removeClassName(shape, 'cube');
        addClassName(shape, 'ring');
    }
    var stage = document.getElementById('stage');

    if (hasClassName(shape, 'ring'))
        stage.style.webkitTransform = 'translateZ(-200px)';
    else
        stage.style.webkitTransform = '';
}

function triggerUpdate() {
    $.post("/api/trigger", function (result) {
        if (!result || result.Planes.length != 12) {
            console.log("Invalid cube config.");
            return;
        }
        for (i = 0; i < 12; i++) {
            var plane = result.Planes[i];
            var planeDiv = $('#shape div:nth-child(' + (i+1) + ')');
            planeDiv.css('font-size', plane.FontSize);
            planeDiv.css('color', plane.TextColor);
            planeDiv.html(plane.Text);
        }
    });
}