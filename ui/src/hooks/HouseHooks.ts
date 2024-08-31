import { useNavigate } from "react-router-dom"
import config from "../config"
import { House } from "../types/house"
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import axios, { AxiosError, AxiosResponse } from "axios"
import Problem from "../types/problem"

export const useFetchHouses = () => {
  return useQuery<House[], AxiosError>({
    queryKey: ['houses'],
    queryFn: () => {
      return axios.get(`${config.baseUrl}/houses`).then(resp => resp.data)
    }
  })
}

export const useFetchHouseDetail = (id: number) => {
  return useQuery<House, AxiosError>({
    queryKey: ['houses', id],
    queryFn: () => {
      return axios.get(`${config.baseUrl}/houses/${id}`).then(resp => resp.data)
    },
  })
}

export const useAddHouse = () => {
  const nav = useNavigate()
  const queryClient = useQueryClient()

  return useMutation<AxiosResponse, AxiosError<Problem>, House>({
    mutationFn: h => axios.post(`${config.baseUrl}/houses`, h),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['houses'] })
      nav('/')
    }
  })
}

export const useUpdateHouse = () => {
  const nav = useNavigate()
  const queryClient = useQueryClient()

  return useMutation<AxiosResponse, AxiosError<Problem>, House>({
    mutationFn: h => axios.put(`${config.baseUrl}/houses`, h),
    onSuccess: (_, house) => {
      queryClient.invalidateQueries({ queryKey: ['houses'] })
      nav(`/house/${house.id}`)
    }
  })
}

export const useDeleteHouse = () => {
  const nav = useNavigate()
  const queryClient = useQueryClient()

  return useMutation<AxiosResponse, AxiosError, House>({
    mutationFn: h => axios.delete(`${config.baseUrl}/houses/${h.id}`),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['houses'] })
      nav(`/`)
    }
  })
}