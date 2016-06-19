var westeros_map = function () {

    var stage = new createjs.Stage("westeros-map");
    var scale = 0.3;
    var alpha = 0.8;

    var tick = function () {
        stage.update();
    };

    var clickRegion = function (event) {
        var region = event.currentTarget.model;
        region.troops++;
        alert("Região: " + region.name + ", Tropas: " + region.troops);
    };

    var getRegions = function () {
        return ($.ajax({
            url: "maps/regions",
            type: "GET"
        }));
    };

    var createBitmap = function (element) {
        var bitmap = new createjs.Bitmap(new Image().src = element.Src);
        bitmap.x = element.X;
        bitmap.y = element.Y;
        bitmap.model = {
            id : element.Id,
            name : element.Name,
            troops : element.Troops
        };
        bitmap.scaleX = bitmap.scaleY = scale;
        bitmap.alpha = alpha;
        bitmap.addEventListener("click", clickRegion);
        bitmap.addEventListener("mouseover",  function () {
            bitmap.alpha = 1;
        });
        bitmap.addEventListener("mouseout", function () {
            bitmap.alpha = alpha;
        });
        bitmap.cursor = "pointer";
        stage.enableMouseOver();
        stage.addChild(bitmap);
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