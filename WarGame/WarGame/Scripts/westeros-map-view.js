﻿var westeros_map = function () {

    var stage = new createjs.Stage("westeros-map");
    var scale = 0.3;
    var alpha = 0.8;

    var tick = function () {
        stage.update();
    };

    var getRegions = function () {
        return ($.ajax({
            url: "maps/regions",
            type: "GET"
        }));
    };

    var createBitmap = function (element) {
        var bitmap = new createjs.Bitmap(new Image().src = element.RegionsPosition.Src);
        var shape = new createjs.Shape();
        var text = new createjs.Text(1, 'bold 15px Helvica', '#000');

        text.align = "center";
        text.x = element.RegionsPosition.TroopsX - 4.5;
        text.y = element.RegionsPosition.TroopsY - 8;

        shape.graphics.beginFill("#89b491");
        shape.graphics.beginStroke("#000");
        shape.graphics.setStrokeStyle(1);
        shape.graphics.drawCircle(element.RegionsPosition.TroopsX, element.RegionsPosition.TroopsY, 10);
        shape.shadow = new createjs.Shadow("#000", 4, 4, 15);

        bitmap.x = element.RegionsPosition.RegionX;
        bitmap.y = element.RegionsPosition.RegionY;
        bitmap.model = {
            id : element.Id,
            name : element.Name,
            troops : element.Troops
        };
        bitmap.scaleX = bitmap.scaleY = scale;
        bitmap.alpha = alpha;
        shadow = new createjs.Shadow("#000", 0, 0, 5);
        bitmap.shadow = shadow;

        bitmap.addEventListener("click", function () {
            var region = bitmap.model;
            text.text = ++region.troops;
            if(region.troops > 9){
                text.x = element.RegionsPosition.TroopsX - 8;
                text.y = element.RegionsPosition.TroopsY - 8;
            }
        });
        bitmap.addEventListener("mouseover",  function () {
            bitmap.alpha = 1;
            bitmap.shadow = new createjs.Shadow("#666", 4, 4, 15);
        });
        bitmap.addEventListener("mouseout", function () {
            bitmap.alpha = alpha;
            bitmap.shadow = shadow;
        });
        bitmap.cursor = "pointer";

        stage.enableMouseOver();
        stage.addChild(bitmap);
        stage.addChild(shape);
        stage.addChild(text);
    };

    var buildMap = function () {
        getRegions().done(function (data) {
            data.forEach(createBitmap);          
            createjs.Ticker.on("tick", stage);
        });
    };

    $(document).ready(function () {
        buildMap();     
    });
    
}();