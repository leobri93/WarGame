﻿var westeros_map = function () {

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

        $("#add-troops").on("click", function () {
            var troops = $("#troops-available").val();
            var rid = $("#region-id").val();
            _game.add_troops(rid, troops, stage);
        });

    });


}();

function criaRadioButtonAtaque() {

    document.getElementById("fronteiras-inimigas").innerHTML = "";
    var dados = new Array("A Muralha", "Correrio", "as gemeas");
    for (var i = 0; i < dados.length; i++) {
        document.getElementById("fronteiras-inimigas").innerHTML += "<option value=" + dados[i] + ">" + dados[i] + "</option>" + "<br>";
    }
    
	
}

function criaRadioButtonMovimento() {

    document.getElementById("fronteiras-aliadas").innerHTML = "";
    var dados = new Array("A Muralha", "Correrio", "as gemeas");
    for (var i = 0; i < dados.length; i++) {
        document.getElementById("fronteiras-aliadas").innerHTML += "<option value=" + dados[i] + ">" + dados[i] + "</option>" + "<br>";
    }


}

function rolarDeDados() {
    
    var tropasAtacantes = 2;
    var tropasDefensoras = tropasAtacantes;
    document.getElementById("disputa").innerHTML = "";
    for (var i = 0; i < tropasAtacantes; i++) {
        document.getElementById("disputa").innerHTML += "<div class='dado-atacante'>" + "<h5 id='numero-dado'>"+Math.floor((Math.random() * 6) + 1); +"<h5>"+"</div>";
    }
    document.getElementById("disputa").innerHTML += "<br><br><h4>Versus</h4><br>";
    for (var i = 0; i < tropasDefensoras; i++) {
        document.getElementById("disputa").innerHTML += "<div class='dado-defensor'>" + "<h5 id='numero-dado'>" + Math.floor((Math.random() * 6) + 1); +"<h5>" + "</div>";
    }
}

