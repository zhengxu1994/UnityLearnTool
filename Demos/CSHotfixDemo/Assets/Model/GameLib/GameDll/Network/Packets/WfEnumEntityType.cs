using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

//ʵ������
public enum EEntityType
{
	EEntityType_None = 0,		//Ĭ��ֵ
	EEntityType_HumanSelf = 1,		//�Լ�����
	EEntityType_Human = 2,		//��������
	EEntityType_NPC = 4,		//npc
	EEntityType_Monster = 8,		//����
	EEntityType_Pet = 16,		//����
	EEntityType_Bullet = 32,		//�ӵ�
	EEntityType_Goods = 64,		//������
};
 public class EEntityType_EnumString 
	{ 
	
	private const string EEntityType_None = "EEntityType_None";
	private const string EEntityType_HumanSelf = "EEntityType_HumanSelf";
	private const string EEntityType_Human = "EEntityType_Human";
	private const string EEntityType_NPC = "EEntityType_NPC";
	private const string EEntityType_Monster = "EEntityType_Monster";
	private const string EEntityType_Pet = "EEntityType_Pet";
	private const string EEntityType_Bullet = "EEntityType_Bullet";
	private const string EEntityType_Goods = "EEntityType_Goods";    
	public static string GetString(int _type)
	{ 
	 
	if(_type == 0){return EEntityType_None;}
	if(_type == 1){return EEntityType_HumanSelf;}
	if(_type == 2){return EEntityType_Human;}
	if(_type == 4){return EEntityType_NPC;}
	if(_type == 8){return EEntityType_Monster;}
	if(_type == 16){return EEntityType_Pet;}
	if(_type == 32){return EEntityType_Bullet;}
	if(_type == 64){return EEntityType_Goods;}
	return "";
	}
	}
