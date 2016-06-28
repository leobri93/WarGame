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