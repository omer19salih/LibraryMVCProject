"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.readFileAsDataURL = readFileAsDataURL;
exports.createImage = createImage;
var jquery_1 = require("jquery");
/**
 * @method readFileAsDataURL
 *
 * read contents of file as representing URL
 *
 * @param {File} file
 * @return {Promise} - then: dataUrl
 */
function readFileAsDataURL(file) {
    return jquery_1.default.Deferred(function (deferred) {
        jquery_1.default.extend(new FileReader(), {
            onload: function (e) {
                var dataURL = e.target.result;
                deferred.resolve(dataURL);
            },
            onerror: function (err) {
                deferred.reject(err);
            }
        }).readAsDataURL(file);
    }).promise();
}
/**
 * @method createImage
 *
 * create `<image>` from url string
 *
 * @param {String} url
 * @return {Promise} - then: $image
 */
function createImage(url) {
    return jquery_1.default.Deferred(function (deferred) {
        var $img = (0, jquery_1.default)('<img>');
        $img.one('load', function () {
            $img.off('error abort');
            deferred.resolve($img);
        }).one('error abort', function () {
            $img.off('load').detach();
            deferred.reject($img);
        }).css({
            display: 'none'
        }).appendTo(document.body).attr('src', url);
    }).promise();
}
//# sourceMappingURL=async.js.map