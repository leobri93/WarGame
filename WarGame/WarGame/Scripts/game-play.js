var game_play = function () {

    var error = function (data) {
        $(".name-region").empty().append(data.responseJSON.name);
        $("#msg").empty().append(data.responseJSON.message);
        $("#modal-error").modal("show");
    };

    var changeText = function (name, troops, stage) {
        var child = stage.getChildByName(name + " Text");
        if(child.text < 10 && troops > 9) child.x -= 4.0;
        if (child.text > 9 && troops < 10) child.x += 4.5;
        child.text = troops;
    };

    var roll_the_dice = function (aplayer, dplayer) {
        var size = (aplayer.length >= dplayer.length) ? aplayer.length : dplayer.length;
        for (var i = 0; i < size; i++) {
            var resultAttack = (typeof aplayer[i] !== 'undefined') ? aplayer[i] : "x";
            var resultDefense = (typeof dplayer[i] !== 'undefined') ? dplayer[i] : "x";
            $("#roll-the-dice").append("<div class='row dice'><div class='col-md-2'><div class='dado-atacante'>" + resultAttack + "</div></div><div class='col-md-1 ex'>x</div><div class='col-md-2'><div class='dado-defense'>" + resultDefense + "</div></div></div>");
        }
    };
    var attack = function (rid, pid) {
        $.ajax({
            url: "/maps/"+pid+"/attack/"+rid,
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
                error(data);
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
                $(".regions-battle").append(data.attackName + " x " + data.defenseName);
                $(".result").append("<div class='row'><div class='col-md-6'>" + data.attackName + ":" + data.resultBattle[0] + " tropa (s)</div><div class='col-md-6'>" + data.defenseName + ":" + data.resultBattle[1] + " tropa (s)</div></div>");      
                roll_the_dice(data.aplayer, data.dplayer);
                $("#modal-ataque").modal("hide");
                $("#resultado-disputa").modal("show");
                changeText(data.attackName, data.attackTroops, stage);
                changeText(data.defenseName, data.defenseTroops, stage);
                if (data.color != null) {
                    var childShape = stage.getChildByName(data.defenseName + " Shape");
                    childShape.graphics._fill.style = data.color;
                }
            },
            error: function (data) {
                error(data);
            }
        });
    };

    var troops_to_distribute = function (pid) {
        $.ajax({
            url: "maps/troops-to-distribute/" + pid,
            type: "GET",
            success: function (data) {
                $("#troops-to-distributed").val(data.troopsToDistribute);
            }
        });
    };
    
    var distributed_troops = function (rid, pid, troopsToDistribute) {
        $.ajax({
            url: "maps/"+pid+"/distribute-troops/"+rid,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $(".distribute").empty();
                $("#qtd-tropas").append(troopsToDistribute);
                $(".name-region").append(data.name);
                $("#region-id").val(rid);
                for (var i = troopsToDistribute; i > 0; i--) $("#troops-available").append('<option>' + i + '</option>');
                $("#modal-distribui").modal('show');
            },
            error: function (data) {
                error(data);
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
                changeText(data.name, data.troops, stage);
                $("#modal-distribui").modal('hide');
            },
            error: function (data) {
                error(data);
            }
        });
    };
    
    var move_troops = function (rid, pid) {
        $.ajax({
            url: "maps/"+pid+"/move-troops/"+rid,
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
                error(data);
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
                $("#modal-mov-tropas").modal('hide');
                changeText(data.nameSource, data.sourceTroops, stage);
                changeText(data.nameDestination, data.destinationTroops, stage);
            },
            error: function (data) {
                error(data);
            }
        });
    };

    return {
        attack: attack,
        battle: battle,
        distributed_troops: distributed_troops,
        troops_to_distribute: troops_to_distribute,
        add_troops: add_troops,
        move_troops: move_troops,
        transfer_troops: transfer_troops
    }

}();