﻿using NotesWindowsFormsApp.Models;
using System;
using System.Collections.Generic;

namespace NotesWindowsFormsApp.Repo
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Находит список задач на данную дату.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<UserTask> GetByDate(DateTime date);
        /// <summary>
        /// Принимает видоизмененную задачу, находит ее старую версию по ID, меняет значения полей и присваивает соответствующие даты и тэги.
        /// </summary>
        /// <param name="task"></param>
        void Update(UserTask task);
        /// <summary>
        /// Принимает Id задачи, которую хотим удалить, и при нахождении удаляет.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        /// <summary>
        /// Принимает задачу, валидирует ее, при прохождении валидации -- сохраняет. 
        /// </summary>
        /// <param name="task"></param>
        void TryToAdd(UserTask task);
        UserTask FindById(int id);
        /// <summary>
        /// Просматривает значения поля Alert всех задач, выбирает списком сегодняшние
        /// </summary>
        /// <returns></returns>
        List<UserTask> GetTodayAlerts();
        /// <summary>
        /// Выбирает те даты, которые больше сегодняшней, и в которых есть задачи.
        /// </summary>
        /// <returns></returns>
        List<DateTime> FindAllActualDates();
        List<UserTask> GetAll();


    }
}
