var westeros_map = function () {

    var stage = new createjs.Stage("westeros-map");
    var _game = game_play;
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
        text.name = element.Name + " Text";

        shape.graphics.beginFill(element.Player.Family.Color);
        shape.graphics.beginStroke("#000");
        shape.graphics.setStrokeStyle(1);
        shape.graphics.drawCircle(element.RegionsPosition.TroopsX, element.RegionsPosition.TroopsY, 10);
        shape.shadow = new createjs.Shadow("#000", 4, 4, 15);
        shape.name = element.Name + " Shape";

        bitmap.x = element.RegionsPosition.RegionX;
        bitmap.y = element.RegionsPosition.RegionY;

        bitmap.scaleX = bitmap.scaleY = scale;
        bitmap.alpha = alpha;
        shadow = new createjs.Shadow("#000", 0, 0, 5);
        bitmap.shadow = shadow;

        bitmap.addEventListener("click", function () {
              _game.distributed_troops(element.Id, element.Player.Id);
          //  _game.move_troops(element.Id);
          //  _game.attack(element.Id);
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
        bitmap.name = element.Name + " Bitmap";
        stage.enableMouseOver();
        stage.addChild(bitmap, shape, text);
    };

    var buildMap = function () {
        getRegions().done(function (data) {
            data.forEach(createBitmap);          
            createjs.Ticker.on("tick", stage);
        });
    };

    $(document).ready(function () {
        buildMap();

        $("#add-troops-btn").on("click", function () {
            var troops = $("#troops-available").val();
            var rid = $("#region-id").val();
            _game.add_troops(rid, troops, stage);
        });

        $("#move-btn").on("click", function () {
            var sid = $(".region-id").val();
            var did = $("#fronteiras-aliadas").val();
            var troops = $("#move-troops").val();
            _game.transfer_troops(sid, did, troops, stage);
        });

        $("#attack").on("click", function () {
            var atroops = $("#troops-attack").val();
            var did = $("#fronteiras-inimigas").val();
            var aid = $(".region-id").val();
             _game.battle(aid, did, atroops, stage);
        });

    });

}();