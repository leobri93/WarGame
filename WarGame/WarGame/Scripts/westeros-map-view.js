var westeros_map = function () {

    var stage = new createjs.Stage("westeros-map");
    var _game_play = game_play;
    var scale = 0.3;
    var alpha = 0.8;
    var turn_name = ["Distribuição de tropas", "Ataque", "Mover tropas"];
    var turn_player = 0;
    var turn = 0;
    var round = 0;

    var tick = function () {
        stage.update();
    };

    var getRegions = function () {
        return ($.ajax({
            url: "maps/regions",
            type: "GET"
        }));
    };

    var getPlayer = function () {
        $.ajax({
            url: "maps/player-turn/" + turn_player,
            type: "GET",
            success: function (data) {
                $("#player-name").empty();
                $("#player-name").append(data.player.Name+" "+data.player.Family.Name);
                $("#player-id").val(data.player.Id);
                _game_play.troops_to_distribute(data.player.Id);
            }
        });
    };

    var nextTurn = function () {
        if (round == 0) {
            turn = 3;
        } else { ++turn; }
        if (turn > 2) nextPlayer();
        $(".turn-name").empty().append(turn_name[turn]);
        if (turn != 0) { $("#troops-to-distributed").addClass("hidden"); }
        else { $("#troops-to-distributed").removeClass("hidden"); }
    };

    var nextPlayer = function () {
        turn = 0;
        turn_player += 1;
        if (turn_player > 2) {
            turn_player = 0;
            nextRound();
        }
        getPlayer();
    };

    var nextRound = function () {
        round++;
        $("#round").empty().append(round + "º Round");
    };

    var createBitmap = function (element) {
        var bitmap = new createjs.Bitmap(new Image().src = element.RegionsPosition.Src);
        var shape = new createjs.Shape();
        var text = new createjs.Text(1, 'bold 15px Helvica', '#000');
        var tooltipText = new createjs.Text("", 'bold 15px Helvica', '#fff');

        text.align = "center";
        text.x = element.RegionsPosition.TroopsX - 4.5;
        text.y = element.RegionsPosition.TroopsY - 8;
        text.name = element.Name + " Text";
        
        tooltipText.align = "center";
        tooltipText.x = element.RegionsPosition.TroopsX - 40;
        tooltipText.y = element.RegionsPosition.TroopsY + 5;
        tooltipText.zIndex = 1111100;

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
            switch(turn) {
                case 0:
                    _game_play.distributed_troops(element.Id, $("#player-id").val(), $("#troops-to-distributed").val());
                    break;
                case 1:
                    _game_play.attack(element.Id, $("#player-id").val());
                    break;
                case 2:
                    _game_play.move_troops(element.Id, $("#player-id").val());
                    break;
            }   
        });

        bitmap.addEventListener("mouseover",  function () {
            bitmap.alpha = 1;
            bitmap.shadow = new createjs.Shadow("#666", 4, 4, 15);
            tooltipText.text = element.Name;
        });
        bitmap.addEventListener("mouseout", function () {
            bitmap.alpha = alpha;
            bitmap.shadow = shadow;
            tooltipText.text = "";
        });
        bitmap.cursor = "pointer";
        bitmap.name = element.Name + " Bitmap";
        stage.enableMouseOver();
        stage.addChild(bitmap, shape, text, tooltipText);
    };

    var buildMap = function () {
        getRegions().done(function (data) {
            data.forEach(createBitmap);          
            createjs.Ticker.on("tick", stage);
        });
    };

    $(document).ready(function () {
        buildMap();

        getPlayer();

        $("#add-troops-btn").on("click", function () {
            var rid = $("#region-id").val();
            var numTroops = $("#troops-available").val();
            var troopsToDistributed = $("#troops-to-distributed").val();
            if ((troopsToDistributed - numTroops) < 1) nextTurn();
            $("#troops-to-distributed").val((troopsToDistributed - numTroops));
            _game_play.add_troops(rid, numTroops, stage);
        });

        $("#move-btn").on("click", function () {
            var sid = $(".region-id").val();
            var did = $("#fronteiras-aliadas").val();
            var troops = $("#move-troops").val();
            _game_play.transfer_troops(sid, did, troops, stage);
        });

        $("#attack").on("click", function () {
            var atroops = $("#troops-attack").val();
            var did = $("#fronteiras-inimigas").val();
            var aid = $(".region-id").val();
            _game_play.battle(aid, did, atroops, stage);
        });

        $("#pass-round").on("click", function () {
            nextTurn();
        });

        $("#objective").on("click", function () {
            $("#modal-objetivo").modal("show");
        });

        $("#label").on("click", function () {
            $("#modal-label").modal("show");
        });

        $("#bonus").on("click", function () {
            $("#modal-bonus").modal("show");
        });
    });

}();