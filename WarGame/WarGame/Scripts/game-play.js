var game_play = function () {

    var attack = function (rid) {
        $.ajax({
            url: "/maps/attack/"+rid,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $(".distribute").empty();
                $(".name-region").append(data.name);
                $(".region-id").val(rid);
                for (var i = data.maxTroopsAttack; i > 0; i--) $("#troops-attack").append('<option>' + i + '</option>');
                for (var i = 0; i < data.enemyBorders.length; i++) $("#fronteiras-inimigas").append('<option value=' + data.enemyBorders[i].Id + '>' + data.enemyBorders[i].Name + '</option>');
                $("#modal-ataque").modal("show");
            },
            error: function (data) {
                debugger;
                alert(data.message);
            }
        });
    };

    var battle = function (aid, did, atroops, stage) {
        $.ajax({
            url: "maps/battle",
            type: "POST",
            dataType: "json",
            data: { aid: aid, did: did, atroops: atroops },
            success: function (data) {
                $(".distribute").empty();
                for (var i = 0; i < data.aplayer.length; i++) $("#region-attack").append("<div class='dado-atacante'><h5 id='numero-dado'>" + data.aplayer[i] + "<h5></div>");
                for (var i = 0; i < data.dplayer.length; i++) $("#region-defense").append("<div class='dado-defensor'><h5 id='numero-dado'>" + data.dplayer[i] + "<h5></div>");
                $(".winner").append(data.victory);
                $("#modal-ataque").modal("hide");
                $("#resultado-disputa").modal("show");
                var attackChild = stage.getChildByName(data.attackName + " Text");
                var defenseChild = stage.getChildByName(data.defenseName + " Text");
                attackChild.text = data.attackTroops;
                defenseChild.text = data.defenseTroops;
                if (data.color != null) {
                    var childShape = stage.getChildByName(data.defenseName + " Shape");
                    childShape.graphics._fill.style = data.color;
                    stage.update();
                }
                if (attackChild.text > 9) attackChild.x -= 4;
                if (defenseChild.text > 9) attackChild.x -= 4;
                if (attackChild.text <= 9) attackChild.x -= 4.5;
                if (defenseChild.text <= 9) attackChild.x -= 4.5;
            },
            error: function (data) {
                debugger;
                alert(data.message);
            }
        });
    };

    var distributed_troops = function (rid, pid) {
        $.ajax({
            url: "maps/"+rid+"/distribute-troops/"+pid,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $(".distribute").empty();
                $("#qtd-tropas").append(data.troopsToDistribute);
                $(".name-region").append(data.name);
                $("#region-id").val(rid);
                for (var i = data.troopsToDistribute; i > 0; i--) $("#troops-available").append('<option>' + i + '</option>');
                $("#modal-distribui").modal('show');
            },
            error: function (data) {
                debugger;
            }
        });
    };

    var add_troops = function (rid, troops, stage) {
        $.ajax({
            url: "maps/add-troops",
            type: "POST",
            dataType: "json",
            data: {rid: rid, troops: troops },
            success: function (data) {
                var child = stage.getChildByName(data.name + " Text");
                child.text = data.troops;
                if (child.text > 9) {
                    child.x -= 4;
                }
                $("#modal-distribui").modal('hide');
            },
            error: function (data) {
                debugger;
            }
        });
    };
    
    var move_troops = function (rid) {
        $.ajax({
            url: "maps/move-troops/"+rid,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $(".distribute").empty();
                $(".qtd-troops").append(data.troops+1);
                $(".name-region").append(data.name);
                $(".region-id").val(rid);
                for (var i = 0; i < data.friendlyBorders.length; i++) $("#fronteiras-aliadas").append('<option value=' + data.friendlyBorders[i].Id + '>' + data.friendlyBorders[i].Name + '</option>');
                for (var i = data.troops; i > 0; i--) $("#move-troops").append('<option>' + i + '</option>');
                $("#modal-mov-tropas").modal('show');
            },
            error: function (data) {
                debugger;
            }
        });
    };

    var transfer_troops = function (sid, did, troops, stage) {
        $.ajax({
            url: "maps/transfer-troops",
            type: "POST",
            dataType: "json",
            data: { sid: sid, did: did, troops: troops },
            success: function (data) {
                var sourceChild = stage.getChildByName(data.nameSource + " Text");
                var destinationChild = stage.getChildByName(data.nameDestination + " Text");
                sourceChild.text = data.sourceTroops;
                destinationChild.text = data.destinationTroops;
                if (sourceChild.text > 9) child.x -= 4;
                if (destinationChild.text > 9) child.x -= 4;
                $("#modal-mov-tropas").modal('hide');
            },
            error: function (data) {
                debugger;
            }
        });
    };


    return {
        attack: attack,
        battle: battle,
        distributed_troops: distributed_troops,
        add_troops: add_troops,
        move_troops: move_troops,
        transfer_troops: transfer_troops
    }

}();